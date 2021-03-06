﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ViannaWebCrawler
{
    public class GradebookRequest
    {
        public string Url { get; set; } = "http://aluno.viannajr.edu.br/intranet/academico/boletim";
        public HttpClient Client { get; private set; }

        public GradebookRequest(HttpClient client)
        {
            Client = client;
        }

        public string GradebookPageRequest()
        {
            var response = Client.GetStringAsync(Url);
            response.Wait();

            //TODO: Pensar em  uma forma melhor de validar e alertar isso
            if (response.IsFaulted)
                throw new Exception("The request was failed");

            return response.Result;
        }

    }
}
