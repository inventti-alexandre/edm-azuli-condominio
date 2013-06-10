﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class Visitas
    {
        public Nullable<DateTime> VisitaData {get;set;}
        public int VisitanteId {get;set;}
        public int Bloco {get;set;}
        public int Apartamento {get;set;}
        public string VisitaPlacaCarro {get;set;}
        public string VistaModeloCarro {get;set;}
        public string VisitaCorCarro {get;set;}
        public string VisitaAutorizada {get;set;}
        public string VisitaAutorizadaPor {get;set;}
        public string VistaObs { get; set; }

        public Visitas()
        {
            VisitaData          = DateTime.Parse("01-01-1753");
            VisitanteId         = 0;
            Bloco               = 0;
            Apartamento         = 0;
            VisitaPlacaCarro    = "";
            VistaModeloCarro    = "";
            VisitaCorCarro      = "";
            VisitaAutorizada    = "";
            VisitaAutorizadaPor = "";
            VistaObs            = "";
        }
    }

    public class listaVisitas : List<Visitas>
    {

    }
}
