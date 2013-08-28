﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using Azuli.Web.Portal.Util;
using System.Text;
using System.Globalization;

namespace Azuli.Web.Portal
{
    public partial class AreaAdministrativa : Util.Base
    {
        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        AgendaModel oAgendaModel = new AgendaModel();
        AgendaBLL oAgendaBLL = new AgendaBLL();
        Util.Util oUtil = new Util.Util();
      
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {
                   
                    hiddenControlDiv();
                    lblDataReserva.Text = dataByExtense();
                }
                else
                {
                    
                   
                }
            }
        }

        public void statusDiasChurrasSalao()
        {
            oAPmodel.bloco = Convert.ToInt32(Session["MoradorSemInternetBloco"]);
            oAPmodel.apartamento = Convert.ToInt32(Session["MoradorSemInternetAP"]);
            lblChurras.Text =  oAgendaBLL.quantidadeDiasReservaChurras(oAPmodel).ToString();
            lblSalao.Text = oAgendaBLL.quantidadeDiasReservaFesta(oAPmodel).ToString();

        }

        public string dataByExtense()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            DateTime dataReserva = new DateTime();
            dataReserva = Convert.ToDateTime(Session["dataReservaAdministrador"]);

            int dia = dataReserva.Day;
            int ano = dataReserva.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(dataReserva.Month));
            string diaSemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(dataReserva.DayOfWeek));

            string dataRetorno = diaSemana + ", " + dia + " de " + mes + " de " + ano;

            return dataRetorno;
          
        }

        /// <summary>
        /// Esconde Controles Botãos/Divs
        /// </summary>
        public void hiddenControlDiv()
        {
            dvDadosMorador.Visible = false;
            lblMsg.Visible = false;
            btnCadastrar.Visible = false;
            btnCancelar.Visible = false;
            dvCadastro.Visible = false;
            dvNewUser.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            dvChurras.Visible = false;

        }


        /// <summary>
        /// Ativa controles
        /// </summary>
        public void activeControlDiv()
        {
            dvDadosMorador.Visible = true;
            statusDiasChurrasSalao();
            dvChurras.Visible = true;
            dvSalaoEstatistica1.Visible = true;
           
        }


        /// <summary>
        /// Evento do botão 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {

           
            oAPmodel.apartamento = Convert.ToInt32(txtAp.Text);
            oAPmodel.bloco = Convert.ToInt32(drpBloco.Text);

            if (oProprietario.BuscaMoradorAdmin(oAPmodel).Count > 0)
            {
                dvCadastro.Visible = false;
                dvDadosMorador.Visible = false;
                dvChurras.Visible = false;
                dvSalaoEstatistica1.Visible = false;
                dvNewUser.Visible = false;
                dvPesquisaMorador.Visible = false;
                foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
                {
                    lblApartDesc.Text = item.ap.apartamento.ToString();
                    lblBlocoDesc.Text = item.ap.bloco.ToString();
                    lblProprietarioDesc.Text = item.proprietario1.ToString();

                    Session["MoradorSemInternetAP"] = item.ap.apartamento;
                    Session["MoradorSemInternetBloco"] = item.ap.bloco;
                    Session["MoradorSemInternetNome1"] = item.proprietario1.ToString();
                    Session["MoradorSemInternetNome2"] = item.proprietario2.ToString();


                    //Session["AP"] = item.ap.apartamento;
                    //Session["Bloco"] = item.ap.bloco;
                   // Session["MoradorSemInternetNome1"] = item.proprietario1.ToString();
                    //Session["MoradorSemInternetNome2"] = item.proprietario2.ToString();

                }

                activeControlDiv();
            }
            else
            {
                dvNewUser.Visible = true;
                dvPesquisaMorador.Visible = false;
                dvDadosMorador.Visible = false;
                dvChurras.Visible = false;
                dvSalaoEstatistica1.Visible = false;
                lblMsg.Visible = true;
                btnCadastrar.Visible = true;
                btnCancelar.Visible = true;
                lblMsg.Text = "Não existem cadastro para este Apartamento e Bloco, <br/> Deseja Cadastrar? </br>";
            }
           
        }

     
        protected void btnOkPesquisa_Click(object sender, EventArgs e)
        {
           
         
            Response.Redirect("telaAgendamentoAdmin.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            lblMsg.Visible = false;
            btnCadastrar.Visible = false;
            dvNewUser.Visible = false;
            dvPesquisaMorador.Visible = true;
        }

        protected void btnCancel0_Click(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            dvCadastro.Visible = true;
            dvDadosMorador.Visible = false;
            dvChurras.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            btnCancelar.Visible = false;
            lblMsg.Visible = false;
            btnCadastrar.Visible = false;
            dvPesquisaMorador.Visible = false;

            txtBlocos.Text = drpBloco.SelectedItem.Text;
            txtApartamento.Text = txtAp.Text;
            dvNewUser.Visible = false;
            
        }

        protected void btnCadastroMorador_Click(object sender, EventArgs e)
        {

           
            oProprietarioModel.ap = new ApartamentoModel();

            oProprietarioModel.ap.bloco = Convert.ToInt32(txtBlocos.Text);
            oProprietarioModel.ap.apartamento = Convert.ToInt32(txtApartamento.Text);
            oProprietarioModel.proprietario1 = txtMorador1.Text;
            oProprietarioModel.proprietario2 = ""; //txtMorador2.Text - Para facilitar para o sindico;
            oProprietarioModel.email = txtEmail.Text;
            oProprietarioModel.senha = oUtil.GeraSenha();
            

        

            try
            {
               int count =  oProprietario.CadastrarApartamentoMorador(oProprietarioModel);

               if (count > 0)
               {
                   lblMsgCadastro.Visible = true;
                   lblMsgCadastro.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;
                
               }

               else
               {
                  
                   lblMsgCadastro.Visible = true;
                   lblMsgCadastro.Text = "Cadastro efetuado com sucesso para Morador: <br> <b> " + oProprietarioModel.proprietario1 + " & " + oProprietarioModel.proprietario2 + " <b> <br>" + "Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento + "<br> Sua Senha é: " + oProprietarioModel.senha + "<br><hr>";
                
                   dvCadastro.Visible = false;
                   dvPesquisaMorador.Visible = false;
                   
                   SendMail enviaEmail = new SendMail();

                   try
                   {
                       int status = 0; 

                       enviaEmail.enviaSenha(lblMsgCadastro.Text, oProprietarioModel.proprietario1, oProprietarioModel.email, status);
                       clearControl();

                   }
                   catch (Exception)
                   {
                       
                       lblMsgCadastro.Visible = true;
                       lblMsgCadastro.Text = "Cadastro efetuado com sucesso para Morador: <br> <b> " + oProprietarioModel.proprietario1 + " & " + oProprietarioModel.proprietario2 + " <b> <br>" + "Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento + "<br> Sua Senha é: " + oProprietarioModel.senha + "<br><hr>";

                       dvCadastro.Visible = false;
                       dvPesquisaMorador.Visible = false;
                   }

                  
                  
                  
                   
              
               }

            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        protected void btnCancel0_Click1(object sender, EventArgs e)
        {
            dvDadosMorador.Visible = false;
            dvChurras.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            dvNewUser.Visible = false;
            dvPesquisaMorador.Visible = true;
            Session.Remove("MoradorSemInternetAP");
            Session.Remove("MoradorSemInternetBloco");
            Session.Remove("MoradorSemInternetNome1");
            Session.Remove("MoradorSemInternetNome2");
        }

        protected void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            clearControl();
            dvDadosMorador.Visible = false;
            dvChurras.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            dvCadastro.Visible = false;
            dvPesquisaMorador.Visible = true;
            lblMsgCadastro.Visible = false;
        }

        public void clearControl()
        {
            txtApartamento.Text = "";
            txtBlocos.Text = "";
            txtMorador1.Text = "";
            //txtMorador2.Text = "";
            txtAp.Text = "";
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }
    }
}