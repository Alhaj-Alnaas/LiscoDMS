using ACS.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Services
{
   public interface IDocServices<T> where T : class
    {
        void AddNewDocs(Message message, List<Doc> docs);
        void DeleteDoc(Doc doc);
        Task<Doc> GetDocByID(Guid Id);
        string GetOriginalDocName(string Id);
        Task<List<string>> GetAllDocsNames();
    }
}
