using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutencaoSolicitacao.Domain.SolicitacoesDeManutencao
{
    public class Contrato
    {
        public string Numero { get; private set; }
        public string NomeDaTerceirizada { get; private set; }
        public string CnpjDaTerceirizada { get; private set; }
        public string GestorDoContrato { get; private set; }
        public DateTime DataFinalDaVigencia { get; private set; }

        public Contrato(string numero, string nomeDaTerceirizada, string cnpjDaTerceirizada, string gestorDoContrato, DateTime dataFinalDaVigencia)
        {
            DomainException.LancarQuadro(string.IsNullOrEmpty(numero), "Numero Contrato invalido");
            DomainException.LancarQuadro(string.IsNullOrEmpty(nomeDaTerceirizada), "Nome da Terceirizada Invalida");
            DomainException.LancarQuadro(string.IsNullOrEmpty(cnpjDaTerceirizada) || cnpjDaTerceirizada.Length != 14, "CNPJ da terceirizada invalida");
            DomainException.LancarQuadro(string.IsNullOrEmpty(gestorDoContrato), "O Gestor é invalido");
            DomainException.LancarQuadro(dataFinalDaVigencia.Date < DateTime.Now.Date, "Data Inserida esta incorreta");
            Numero = numero;
            NomeDaTerceirizada = nomeDaTerceirizada;
            CnpjDaTerceirizada = cnpjDaTerceirizada;
            GestorDoContrato = gestorDoContrato;
            DataFinalDaVigencia = dataFinalDaVigencia;
        }
     }
}
 