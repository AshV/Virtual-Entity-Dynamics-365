using EBooksODataAPI.Data;
using EBooksODataAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBooksODataAPI.DB
{
    public class EBookDB
    {
            private static EBookDB instance = null;
            public static EBookDB Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new EBookDB();
                    }
                    return instance;
                }
            }
            public List<EBook> EBooks { get; set; }

            private EBookDB()
            {
                this.Reset();
                this.Initialize();
            }
            public void Reset()
            {
                this.EBooks = new List<EBook>();

            }
            public void Initialize()
            {
            var jsonData = JsonConvert.DeserializeObject<JsonDataModel>(JsonData.Books);
            foreach (var book in jsonData.Books)
            {
                string BookGuid;
                GuidMapper.Map.TryGetValue(book.ID.ToString(), out BookGuid);
                this.EBooks.Add(new EBook
                {
                    ID = Guid.Parse(BookGuid),
                    Title = book.Title,
                    SubTitle = book.SubTitle,
                    Description = book.Description,
                    Image = book.Image,
                    isbn = book.isbn
                });
            }
        }
        }
    }
