using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class DocumentService : Service, IDocumentService
    {
        public DocumentService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
