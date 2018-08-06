using EBookCustomDataProvider.Data;
using EBookCustomDataProvider.Models;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EBookCustomDataProvider.Database
{
    public class EBooksDB
    {
        private static EBooksDB instance = null;

        public static EBooksDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EBooksDB();
                }
                return instance;
            }
        }

        public EntityCollection Ebooks { get; set; }

        private EBooksDB()
        {
            this.Reset();
            this.Initialize();
        }

        public void Reset()
        {
            this.Ebooks = new EntityCollection();
        }

        public void Initialize()
        {
            var jsonData = JsonConvert.DeserializeObject<JsonDataModel>(JsonData.Books);
            foreach (var book in jsonData.Books)
            {
                string BookGuid;
                GuidMapper.Map.TryGetValue(book.ID.ToString(), out BookGuid);
                this.Ebooks.Entities.Add(new Entity("d365in_book", Guid.Parse(BookGuid))
                {
                    ["d365in_bookid"] = Guid.Parse(BookGuid),
                    ["d365in_name"] = book.Title,
                    ["d365in_subtitle"] = book.SubTitle,
                    ["d365in_description"] = book.Description,
                    ["d365in_image"] = book.Image,
                    ["d365in_isbn"] = book.isbn
                });
            }
        }
    }
}