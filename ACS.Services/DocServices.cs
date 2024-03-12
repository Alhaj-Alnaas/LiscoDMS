using ACS.Core.Entities;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Services
{

    public class DocServices<T> : IDocServices<T> where T : Doc
    {
        private readonly IUnitOfWork<Doc> _unitOfWork;
        private readonly IWebHostEnvironment _hosting;

        public DocServices(
            IUnitOfWork<Doc> unitOfWork
            , IWebHostEnvironment hosting
            )
        {
            _unitOfWork = unitOfWork;
            _hosting = hosting;
        }

        public void AddNewDocs(Message message, List<Doc> docs)
        {
            foreach (var doc in docs)
            {
                doc.Message = message;
                doc.MessageId = message.Id;
                _unitOfWork.Entity.Insert(doc);
                _unitOfWork.Save();
            }
        }

        public void DeleteDoc(Doc doc)
        {
            _unitOfWork.Entity.PermanentDelete(doc);
            _unitOfWork.Save();
        }

        public async Task<Doc> GetDocByID(Guid Id)
        {
            return await _unitOfWork.Entity.FindAsync(m => m.Id == Id);
        }

        public string GetOriginalDocName(string Id)
        {
            return _unitOfWork.Entity.FindAsync(m => m.Id == Guid.Parse(Id)).Result.Name;
        }
        public async Task<List<string>> GetAllDocsNames()
        {
            return (await _unitOfWork.Entity.GetAllAsync()).Select(i => i.Id.ToString()).ToList();
        }
    }
}
