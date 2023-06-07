namespace Back_End.Models
{
    public class SignEntityModel
    {
        public long SignId { get; set; }
        public string Nome { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string Mensagem { get; set; }

        public bool VerificarSigno(DateTime dataRecebida)
        {
            if ((dataRecebida.Day >= Convert.ToInt16(DataInicial[..2]) && dataRecebida.Month.ToString() == DataInicial[3..])
                || (dataRecebida.Day <= Convert.ToInt16(DataFinal[..2]) && dataRecebida.Month.ToString() == DataFinal[3..]))
                return true;
            else return false;

        }
    }
}
