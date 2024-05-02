namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            var quantidadeHospede = hospedes.Count();
            var capacidadeSuite = Suite.Capacidade;
            var suiteSuportaQuantidade = capacidadeSuite >= quantidadeHospede;
            if (suiteSuportaQuantidade)
                Hospedes = hospedes;
            else
                throw new Exception("Capacidade da suite menor que o número de hóspedes recebido");
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            var quandidadeHospede = Hospedes.Count();
            return quandidadeHospede;
        }

        public decimal CalcularValorDiaria()
        {
            var valorDiaria = Suite.ValorDiaria;
            var diasReservados = DiasReservados;
            decimal valor = DiasReservados * valorDiaria;

            if (diasReservados >= 10)
            {
                var desconto = 0.1m;
                valor = valor - (valor * desconto);
            }

            return valor;
        }
    }
}