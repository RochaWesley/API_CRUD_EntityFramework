namespace src.Models;

    public class Contrato
    {
        public Contrato()
        {
            this.DataCriacao = DateTime.Now;
            this.tokenID = "0000";
            this.Valor = 0;
            this.Pago = false;
        }
        public Contrato(string tokenID,double valor)
        {
            this.tokenID = tokenID;
            this.Valor = valor;
            this.Pago = false;
            
        }
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string tokenID { get; set; }
        public double Valor { get; set; }
        public bool Pago { get; set; }
        public int PessoaId { get; set; }
    }
