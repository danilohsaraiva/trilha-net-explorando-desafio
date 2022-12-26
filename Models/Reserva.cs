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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            int capacidadeSuite = 0;

            if(Suite == null) 
            {
                capacidadeSuite = hospedes.Count;
                // Assim consigo adicinar a lista sem problemas
            }
            else
            {
                capacidadeSuite = Suite.Capacidade;
            }

            try
            {
                if (verificaCapacidade(hospedes.Count, capacidadeSuite))
                {
                    Hospedes = hospedes;
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Ocorreu um erro: {ex}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            int quantidadeHospedes = 0;

            if(Hospedes == null)
            {
                quantidadeHospedes = suite.Capacidade;
                //Assim adiciona a suite normalmente
            }
            else
            {
                quantidadeHospedes = ObterQuantidadeHospedes();
            }

            if(verificaCapacidade(quantidadeHospedes, suite.Capacidade))
            {
                Console.WriteLine("Suite adicionada à Reserva com Sucesso!");
                Suite = suite;
            }
            else
            {
                Console.WriteLine("Suite não suporta a quantidade de hospédes!");                
            }
            
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            try
            {
            return Hospedes.Count;
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine($"Não há hóspedes cadastrados {ex}");
                return 0;
            }
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*

            try
            {
                decimal valor = this.DiasReservados * Suite.ValorDiaria;

                // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
                // *IMPLEMENTE AQUI*
                bool diasMaiorIgualDez = (this.DiasReservados >= 10);

                exibeMensagem(diasMaiorIgualDez);

                if (diasMaiorIgualDez)
                {
                    valor -= (valor * 0.1M) ;
                    return valor;
                } 
                else 
                {
                    return valor;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ocorrido: {ex.Message}");
                return 0;
            }
        }

        public bool verificaCapacidade(int quantidadeHospede, int capacidadeSuite)
        {
            return quantidadeHospede <= capacidadeSuite;
        }
        public void exibeMensagem(bool condicao)
        {
            if(condicao)
            {
                Console.WriteLine("Desconto de 10% aplicado");
            }
            else
            {
                Console.WriteLine("Não possuí desconto");
            }
        }
    }
}