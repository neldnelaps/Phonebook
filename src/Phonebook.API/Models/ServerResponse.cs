﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Phonebook.API.Service
{
    class ServerResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public HttpContent HttpContent { get; set; }
    }
}