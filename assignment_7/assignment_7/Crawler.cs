using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_7
{
    class Crawler
    {
        //下载队列
        Queue<string> loadedQueue = new Queue<string>();
        //下载网页
        public Dictionary<string, bool> downloaded { get; } = new Dictionary<string, bool>();

        //委托，爬虫停止
        public event Action<Crawler> CrawlerStopped;
        //委托，下载爬到的页面
        public event Action<Crawler, string, string> PageDownloaded;


        //检测
        public static readonly string UrlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";
        //解析
        public static readonly string urlParseRegex = @"^(?<site>(?<protocal>https?)://(?<host>[\w\d.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";


        //主机过滤
        public string hostFilter { get; set; }
        //文件过滤
        public string fileFilter { get; set; }


        //最大下载数量
        public int maxPage { get; set; }
        //起始网址
        public string beginningURL { get; set; }
        //网页编码
        public Encoding htmlEncoding { get; set; }

        //构造函数
        public Crawler()
        {
            maxPage = 100;
            htmlEncoding = Encoding.UTF8;
        }

        //爬虫的开始函数
        public void Start()
        {
            //初始化，清除已加载的
            downloaded.Clear();
            loadedQueue.Clear();
            loadedQueue.Enqueue(beginningURL);

            while (downloaded.Count < maxPage && loadedQueue.Count > 0)
            {
                string url = loadedQueue.Dequeue();
                try
                {
                    string html = downLoad(url); // 下载
                    downloaded[url] = true;
                    PageDownloaded(this, url, "success");
                    Parse(html, url);//解析、加入新的链接
                }
                catch (Exception ex)
                {
                    downloaded[url] = false;
                    PageDownloaded(this, url, "  Error:" + ex.Message);
                }
            }
            CrawlerStopped(this);
        }

        //下载函数
        private string downLoad(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = downloaded.Count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
        }

        //解析函数
        private void Parse(string html, string pageUrl)
        {
            var matches = new Regex(UrlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "" || linkUrl.StartsWith("javascript:")) continue;
                linkUrl = fixUrl(linkUrl, pageUrl);//转绝对路径
                                                   //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (Regex.IsMatch(host, hostFilter) && Regex.IsMatch(file, fileFilter)
                  && !downloaded.ContainsKey(linkUrl) && !loadedQueue.Contains(linkUrl))
                {
                    loadedQueue.Enqueue(linkUrl);
                }
            }
        }

        //将非完整路径转为完整路径
        static private string fixUrl(string url, string pageUrl)
        {
            //完整路径
            if (url.Contains("://"))
            {
                return url;
            }


            if (url.StartsWith("//"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                string protocal = urlMatch.Groups["protocal"].Value;
                return protocal + ":" + url;
            }

            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            //上一级
            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return fixUrl(url, pageUrl.Substring(0, idx));
            }

            //当前
            if (url.StartsWith("./"))
            {
                return fixUrl(url.Substring(2), pageUrl);
            }
            //非上述开头的相对路径
            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }

    }
}
