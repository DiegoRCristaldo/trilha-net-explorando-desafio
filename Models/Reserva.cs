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
            //Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            bool capacidadePermitida = Suite.Capacidade >= hospedes.Count;
            if(capacidadePermitida){
                Hospedes = hospedes;
            }

            else{
                throw new Exception("O número de hospedes é maior que a capacidade da suite no momneto.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            int i = 0;
            while(i < Hospedes.Count){
                i++;
            }
            return i;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            decimal valorDaDiaria = DiasReservados * Suite.ValorDiaria;

            // Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            bool desconto = DiasReservados >= 10;
            if (desconto)
            {
                valorDaDiaria = valorDaDiaria - (valorDaDiaria / 10);
            }

            return valorDaDiaria;
        }
    }
}