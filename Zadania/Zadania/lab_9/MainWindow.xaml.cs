using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace lab_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DownloadSnip("");



            //Console.WriteLine("    (" + snippet.Size + ")    " + snippet.Name + "    [" + snippet.Type + "]    " + snippet.CreationTime + "    " + snippet.UpdateTime);

        }

        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReposne>(data);
        }


        private void klick(object sender, MouseButtonEventArgs e)
        {
            ClearSnip();
            DownloadSnip(((Technology)sender).Type);
        }
        private void ClearSnip()
        {
            var temp = SName.Children[0];
            SName.Children.Clear();
            SName.Children.Add(temp);
            temp = SType.Children[0];
            SType.Children.Clear();
            SType.Children.Add(temp);
            temp = STime.Children[0];
            STime.Children.Clear();
            STime.Children.Add(temp);
        }
        private void DownloadSnip(string snippetsType)
        {
            int pageNumber = 1;
            int pageSize = 5;

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);

            foreach (SnippetReponse snippet in reponse.Batches)
            {
                TextBox name = new TextBox();
                TextBox type = new TextBox();
                TextBox date = new TextBox();
                name.Text = snippet.Name;
                SName.Children.Add(name);
                type.Text = snippet.Type;
                SType.Children.Add(type);
                date.Text = snippet.CreationTime.ToString();
                STime.Children.Add(date);
            }
        }
    }

    public class PageReposne
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("batches")]
        public List<SnippetReponse> Batches { get; set; }
    }

    public class SnippetReponse
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime? CreationTime { get; set; }

        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; }
    }


}