﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using Azuli.Web.Business;
using System.Globalization;

namespace Azuli.Web.Portal
{
    public partial class detalheOcorrencia :  Util.Base
    {
        Util.Util oUtil = new Util.Util();
        DateTime data = DateTime.Now;
        LancamentoOcorrenciaModel olancamentoModel = new LancamentoOcorrenciaModel();
        LancamentoOcorrencia olancamentoBLL = new LancamentoOcorrencia();
        ApartamentoModel oAp = new ApartamentoModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {
                    preencheMeses();
                    drpMeses.SelectedIndex = data.Month - 1;
                    Session["mes"] = drpMeses.SelectedIndex = data.Month - 1;
                    listaOcorrenciaMes();


                }
            }
        }

         public void listaOcorrenciaMes()
        {
            Util.Util.meses mesesAno;
            
            Enum.TryParse<Util.Util.meses>(drpMeses.SelectedItem.Value, out mesesAno);
            int mes = (int)mesesAno;
            oAp.apartamento =  Convert.ToInt32(Session["AP"]);
            oAp.bloco      = Convert.ToInt32(Session["Bloco"]);
            olancamentoModel.oAp = oAp;

            try
            {

                grdOcorrencias.DataSource = olancamentoBLL.buscaOcorrenciaByMeses(olancamentoModel, mes);
                grdOcorrencias.DataBind();


            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        public void preencheMeses()
        {
            string mesCorrente = "";
            //drpMeses.DataSource = Enum.GetNames(typeof(Util.Util.meses));
            DateTime data = DateTime.Now;

            int meses = 0;

            meses = data.Month;

            
            mesCorrente = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(data.Month);

            drpMeses.Items.Add(mesCorrente); //drpMeses.Items.IndexOf(drpMeses.Items.FindByValue(data.Month.ToString()));

            Dictionary<int, string> dicionarioMeses = new Dictionary<int, string>();

            for (int i = 1 ; i <= meses; i++)
            {
                dicionarioMeses.Add(i, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).ToUpper());
            }
            drpMeses.DataTextField = "Value";
            drpMeses.DataValueField = "Key";
            drpMeses.DataSource = dicionarioMeses;
            drpMeses.DataBind();
        }
        
        protected void drpMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaOcorrenciaMes();
        }

        protected void grdOcorrencias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int numberCode = 0;

            int index = int.Parse((string)e.CommandArgument);
            numberCode = Convert.ToInt32(grdOcorrencias.DataKeys[index]["codigoOcorrencia"]);

            Session["codigoOcorrencia"] = numberCode;

            if (numberCode != 0)
            {
                Response.Redirect("~/listaOcorrenciaMorador.aspx");
                
            }

        }

    }
}