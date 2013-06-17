﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Globalization;
using System.Drawing;
namespace Azuli.Web.Portal
{
    public partial class telaAgendamento : Util.Base
    {
           AgendaBLL oAgenda = new AgendaBLL();
           AgendaModel oAgendaModel = new AgendaModel();
           ApartamentoModel oApModel = new ApartamentoModel();
           Util.Util oUtil = new Util.Util();
           ApartamentoModel oAP = new ApartamentoModel();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (oUtil.validateSession())
            {
             
                if (!IsPostBack)
                {

                   

                    escondeControl();
                   //// lblApartDesc.Text = Session["AP"].ToString();
                   //// lblBlocoDesc.Text = Session["Bloco"].ToString();
                   // if (Session["Proprie2"].ToString() != "")
                   // {
                   //     lblProprietarioDesc.Text = Session["Proprie1"] + " & " + Session["Proprie2"];
                   // }
                   // else
                   // {
                   //     lblProprietarioDesc.Text = Session["Proprie1"].ToString();
                   // }
                    carregaAgendaMesAtual();

                }

            }
            
        }


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            
            Literal litAlugado = new Literal();
            List<AgendaModel> listaAgenda = oAgenda.listaEventos();

         
         

           
            if (e.Day.Date < (System.DateTime.Now.AddDays(-1)))
            {
               
                e.Day.IsSelectable = false;
                e.Cell.Font.Strikeout = true;
                e.Cell.Font.Bold = true;
               
            }

            if (e.Day.IsToday)
            {
                e.Cell.Font.Bold = true;
                e.Cell.ForeColor = System.Drawing.Color.Black;

            }

            foreach (var item in listaAgenda)
            {
               
               
                if (e.Day.Date ==item.dataAgendamento)
                {

                    listAgenda OeventCalendar = new listAgenda();
                    if (item.salaoChurrasco == true & item.salaoFesta == false)
                    {
                      
                        e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF01");
                        TextBox t1 = new TextBox();
                        t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                        t1.Width = 70;
                        t1.Height = 20;
                        t1.TextMode = TextBoxMode.SingleLine;
                        t1.Font.Size = 7;
                        t1.ForeColor = Color.Black;

                        TextBox t2 = new TextBox();
                        t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                        t2.Width = 70;
                        t2.Height = 20;
                        t2.TextMode = TextBoxMode.SingleLine;
                        t2.Font.Size = 7;
                        t2.ForeColor = Color.Black;
                        int count = 0;

                        OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                        foreach (var quemAlugou in OeventCalendar)
                        {
                            if (OeventCalendar.Count >= 2)
                                if (count == 0)
                                {
                                    t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                                    count = 1;
                                }
                                else
                                {
                                    t2.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                                }
                            else
                            {
                                t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;

                            }

                        }

                        Panel p1 = new Panel();
                        p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                        p1.Attributes.Add("style", "display:none;");
                        p1.Attributes.Add("style", "display:none;");
                        p1.Controls.Add(t1);

                        if (t2.Text != "")
                        {
                            p1.Controls.Add(t2);
                        }
                        e.Cell.Controls.Add(p1);
                        e.Cell.Height = 50;
                        e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                        e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");
                        
                       
                      
                    }
                    else if (item.salaoChurrasco == false & item.salaoFesta == true)
                    {
                        
                        e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#BADEF4");
                        TextBox t1 = new TextBox();
                        t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                        t1.Width = 70;
                        t1.Height = 20;
                        t1.TextMode = TextBoxMode.SingleLine;
                        t1.Font.Size = 7;
                        t1.ForeColor = Color.Black;

                        TextBox t2 = new TextBox();
                        t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                        t2.Width = 70;
                        t2.Height = 20;
                        t2.TextMode = TextBoxMode.SingleLine;
                        t2.Font.Size = 7;
                        t2.ForeColor = Color.Black;
                        int count = 0;

                        OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                        foreach (var quemAlugou in OeventCalendar)
                        {
                            if (OeventCalendar.Count >= 2)
                                if (count == 0)
                                {
                                    t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                                    count = 1;
                                }
                                else
                                {
                                    t2.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                                }
                            else
                            {
                                t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                              
                            }

                        }

                        Panel p1 = new Panel();
                        p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                        p1.Attributes.Add("style", "display:none;");
                        p1.Attributes.Add("style", "display:none;");
                        p1.Controls.Add(t1);

                        if (t2.Text != "")
                        {
                            p1.Controls.Add(t2);
                        }
                        e.Cell.Controls.Add(p1);
                        e.Cell.Height = 50;
                        e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                        e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");
                        
                       
                    }
                    else if (item.salaoChurrasco == true & item.salaoFesta == true)
                    {

                           e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#AA0708");
                           TextBox t1 = new TextBox();
                           t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                           t1.Width = 70;
                           t1.Height = 20;
                           t1.TextMode = TextBoxMode.SingleLine;
                           t1.Font.Size = 7;
                           t1.ForeColor = Color.Black;

                           TextBox t2 = new TextBox();
                           t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                           t2.Width = 70;
                           t2.Height = 20;
                           t2.TextMode = TextBoxMode.SingleLine;
                           t2.Font.Size = 7;
                           t2.ForeColor = Color.Black;
                           int count = 0;

                           OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                           foreach (var quemAlugou in OeventCalendar)
                           {
                               if (OeventCalendar.Count >= 2)
                                   if (count == 0)
                                   {
                                       t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                                       count = 1;
                                   }
                                   else
                                   {
                                       t2.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                                   }
                               else
                               {
                                   t2.Text =  "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
                                   t1.Text = "As duas P/";
                               }
                               
                           }
                       
                           Panel p1 = new Panel();
                           p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                           p1.Attributes.Add("style", "display:none;");
                           p1.Attributes.Add("style", "display:none;");
                           p1.Controls.Add(t1);

                           if (t2.Text != "")
                           {
                               p1.Controls.Add(t2);
                           }
                           e.Cell.Controls.Add(p1);
                           e.Cell.Height = 50;
                           e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                           e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");
                           
                           e.Day.IsSelectable = false;
                   }
                   
                    
                }
            }
        }


        public void escondeControl()
        {
            dvOpcao.Visible = false;
          
           
        
        }
        
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            

            List<AgendaModel> oLista = validaData(Calendar1.SelectedDate);
            lblData.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");

            chkSalaoFesta.Visible = true;
            chkChurrascaria.Visible = true;
            
                foreach (var item in oLista)
                {

                    if (item.salaoChurrasco == false && item.salaoFesta == false)
                    {
                        chkSalaoFesta.Visible = true;
                        chkChurrascaria.Visible = true;
                    }
                    else
                    {

                        chkChurrascaria.Visible = item.salaoFesta;
                        chkSalaoFesta.Visible = item.salaoChurrasco; 
                    }



                    //if (item.salaoChurrasco == true & item.salaoFesta  == false)
                    //{
                    //    chkChurrascaria.Visible = false;
                    //    chkSalaoFesta.Visible = true;
                    //    chkSalaoFesta.Checked = true;
                    //}
                    //else if (item.salaoChurrasco == false & item.salaoFesta == true)
                    //{

                    //    chkSalaoFesta.Visible = false;
                    //    chkChurrascaria.Visible = true;
                    //    chkChurrascaria.Checked = true;

                    //}
                    //else if (item.salaoChurrasco == false & item.salaoFesta == false)
                    //{

                    //    chkSalaoFesta.Visible = false;
                    //    chkChurrascaria.Visible = false;
                    //    chkChurrascaria.Checked = false;

                    //}
                    //else if (item.salaoChurrasco == true & item.salaoFesta == true)
                    //{
                    //    chkSalaoFesta.Visible = true;
                    //    chkSalaoFesta.Visible = true;
                    //}
                }

                lblMsgData.Visible = false;
                dvOpcao.Visible = true;
                dvCalendar.Visible = false;
           }
        


        public List<AgendaModel> validaData(DateTime date)
        {
            List<AgendaModel> olistAgenda = new List<AgendaModel>();

            olistAgenda =  oAgenda.listaEventosByData(date);

            return olistAgenda;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            int contadorChurras = 0;
            int contadorFesta = 0;

            if (chkChurrascaria.Checked || chkSalaoFesta.Checked)
            {

                //bool salaoFesta = false;
                //bool churrasco = false;

                //if (chkSalaoFesta.Checked && chkChurrascaria.Checked)
                //{
                //    churrasco = true;
                //    salaoFesta = true;
                //}
                //else if (chkSalaoFesta.Checked && !chkChurrascaria.Checked)
                //{
                //    salaoFesta = true;
                //    churrasco = false;
                //}

                //else if (!chkSalaoFesta.Checked && chkChurrascaria.Checked)
                //{
                //    churrasco = true;
                //    salaoFesta = false;
                //}



                oAgendaModel.salaoChurrasco = chkChurrascaria.Checked;
                oAgendaModel.salaoFesta = chkSalaoFesta.Checked;
                oApModel.apartamento = int.Parse(Session["AP"].ToString());
                oApModel.bloco = int.Parse(Session["Bloco"].ToString());



                try
                {

                     foreach (var item in  oAgenda.validaAgendamento(Convert.ToDateTime(lblData.Text), oApModel, oAgendaModel))
	                 {
                         contadorChurras = item.contadorChurrasco;
                         contadorFesta =  item.contadorFesta;
	                 }

                     if (chkChurrascaria.Checked && contadorChurras <= 0 || chkSalaoFesta.Checked && contadorFesta <= 0)
                     {

                         oAgenda.cadastrarAgenda(Convert.ToDateTime(lblData.Text), oApModel, oAgendaModel);
                         Session["DataConfirmacao"] = lblData.Text;
                         Response.Redirect("TelaConfirmacaoAgendamento.aspx");
                        
                     }
                     else
                     {
                         lblReserva.Text = "Já existem reservas para esta data!!";
                     }

                   
                }

                catch (Exception error)
                {

                    throw error;
                }


                carregaAgendaMesAtual();
            }
            else
            {
                lblReserva.Text = "Favor escolher uma das opções !!";
            }
        }

       
        protected void btnOKConfirma_Click(object sender, EventArgs e)
        {
            Response.Redirect("telaAgendamento.aspx");
        }


        public void carregaAgendaMesAtual()
        {
            oAgendaModel.dataAgendamento = DateTime.Now;
            lblMesAtual.Text = (DateTime.Now.ToString("MMMM", new CultureInfo("pt-BR"))).ToUpper() + "/" + DateTime.Now.Year;
            oAP.bloco = Convert.ToInt32(Session["Bloco"]);
            oAP.apartamento = Convert.ToInt32(Session["AP"]);

            

                formVwChurrasco.DataSource = oAgenda.listaReservaByMorador(oAP, oAgendaModel);
                formVwChurrasco.DataBind();

                frvSalaoFesta.DataSource = oAgenda.listaReservaByMoradorFesta(oAP, oAgendaModel);
                frvSalaoFesta.DataBind();
           
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("telaAgendamento.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Write("<script>window.print();</script>");
        }

        protected void btnOKConfirma_Click1(object sender, EventArgs e)
        {
            Response.Redirect("telaAgendamento.aspx");
        }

       

        protected void formVwChurrasco_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            formVwChurrasco.PageIndex = e.NewPageIndex;
            carregaAgendaMesAtual();
        }

        protected void frvSalaoFesta_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            frvSalaoFesta.PageIndex = e.NewPageIndex;
            carregaAgendaMesAtual();
        }

        protected void UpdateTimer_Tick1(object sender, EventArgs e)
        {
            try
            {

                System.Web.UI.WebControls.TableCell tabela = new TableCell();
                System.Web.UI.WebControls.CalendarDay calendario = new CalendarDay(DateTime.Now, false, false, false, false, "1");


                Calendar1_DayRender(this, new DayRenderEventArgs(tabela, calendario));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void frvSalaoFesta_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {

        }


        /// <summary>
        /// Desabilitado cancelamento direto pela tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void formVwChurrasco_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        //{



        //    const bool salaoFesta = false;
        //    const bool churrasqueira = true;
        //    DateTime dataAgendamento = new DateTime();
        //    string bloco = "";
        //    string ap = "";
        //    DataKey key = formVwChurrasco.DataKey;
        //    dataAgendamento = Convert.ToDateTime(key.Value);
            
        //    if (validaCancelamento(dataAgendamento))
        //    {
        //        bloco = Session["Bloco"].ToString();
        //        ap = Session["Ap"].ToString();
        //        oAP.apartamento = Convert.ToInt32(ap);
        //        oAP.bloco = Convert.ToInt32(bloco);


        //        try
        //        {
        //            oAgenda.cancelaAgendamentoMorador(dataAgendamento, oAP, salaoFesta, churrasqueira);
        //            formVwChurrasco.DataBind();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
         

        //}


        /// <summary>
        /// Desabilitado cancelamento direto pela tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void frvSalaoFesta_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        //{
           


        //        const bool  salaoFesta = true;
        //        const bool churrasqueira = false;
        //        DateTime dataAgendamento = new DateTime();
        //        string bloco = "";
        //        string ap = "";
        //        DataKey key = frvSalaoFesta.DataKey;
        //        dataAgendamento = Convert.ToDateTime(key.Value);
                
        //        if (validaCancelamento(dataAgendamento))
        //        {
        //            bloco = Session["Bloco"].ToString();
        //            ap = Session["Ap"].ToString();
        //            oAP.apartamento = Convert.ToInt32(ap);
        //            oAP.bloco = Convert.ToInt32(bloco);


        //            try
        //            {
        //                oAgenda.cancelaAgendamentoMorador(dataAgendamento, oAP, salaoFesta, churrasqueira);
        //                frvSalaoFesta.DataBind();
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }
        //        }
        //}

        public bool validaCancelamento(DateTime dataAgendamento)
        {

            int diasAgendado;
          
            diasAgendado = ((TimeSpan)(dataAgendamento - DateTime.Now)).Days;
            if (diasAgendado >= 8)
            {
                return true;
            }

            else
            {
                if (diasAgendado == 0)
                {
                    lblMgs.Text = "Não é permitido o cancelamento! Para o mesmo dia da Reserva";

                }
                else
                {
                    lblMgs.Text = "Não é permitido o cancelamento! Permitido só com 15 dias de antecedência e hoje faltam " + diasAgendado + " dias para reserva, excessões procure o síndico ramal 94";
                }
                return false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("telaAgendamento.aspx");
        }
        
    }
}