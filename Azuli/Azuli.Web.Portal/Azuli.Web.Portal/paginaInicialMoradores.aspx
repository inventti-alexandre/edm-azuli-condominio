﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="paginaInicialMoradores.aspx.cs" Inherits="Azuli.Web.Portal.paginaInicialMoradores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            font-family: "Segoe UI";
            font-size: medium;
        }
        .style2
        {
            font-family: "Segoe UI";
            font-size: medium;
            font-weight: bold;
        }
        .style5
        {
            color: #0033CC;
            font-family: "Segoe UI";
            font-size: medium;
            text-decoration: underline;
        }
        .style3
        {
            width: 33px;
            height: 27px;
        }
        .style7
        {
            font-family: "Segoe UI";
            font-weight: normal;
            font-size: small;
            font-variant: normal;
        }
        .style8
        {
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"><br /><br /><br /><br /><br />
 <table style="text-align: justify; height: 101px; width: 941px;">
            <tr>
                <td align="center">
                    <img src="images/azuli.jpg" style="width: 69%; height: 81px" />         
                </td>
                <td align="center">
             <h1 align="left"> &nbsp; Senhor(ª) <asp:Label ID="lblMorador" 
                        runat="server" ForeColor="Blue"></asp:Label>&nbsp;<span class="style7">- Você tem
                 <asp:LinkButton ID="lnkBtnMsg" runat="server" Font-Bold="True" 
                     Font-Size="Medium" ForeColor="#009900" onclick="lnkBtnMsg_Click1">0</asp:LinkButton>
                 <span class="style8">
&nbsp;mensagens&nbsp;
                        <img alt="" class="style3" src="images/correio.jpg" /></span></span></h1>
                </td>
            </tr>
       </table>  
       
      <center> <P class="style5"> Seja bem vindo a intranet do Condominio Spazio Campo Azuli.</P></center>
    <P class="style1"> Através do menu acima, é permitido fazer reservas do salão de festa / Churrasqueira e abrir ocorrências, e consultar informações referente ao condominio, como balancete do mês, estatuto e entre mais informações importantes.
       </P>
       
       <p class="style2">
            Informações importantes sobre o spazio Azuli no link abaixo:
       </p>
      <li style="color:#000080"> <asp:LinkButton ID="link1"  runat="server" 
              onclick="link1_Click">Baixar o Statuto do Condominio</asp:LinkButton></li>
  <br />
        
      <li style="color:#000080"> <asp:LinkButton ID="Link2" runat="server" 
              onclick="Link2_Click">Consultar Nomes e contatos: Sindico/Subsindico e Conselheiros</asp:LinkButton></li>
          <br />
      <li style="color:#000080"> <asp:LinkButton ID="link4" runat="server" 
              onclick="link4_Click">Consultar Nomes e contatos/funções dos funcionários do Condominio</asp:LinkButton></li>

            
         <br />
        <p>
            A Solução permite gerenciar, de modo on-line, todas as funcionalidades, em um ambiente seguro e robusto.
        </p>
                

</asp:Content>
