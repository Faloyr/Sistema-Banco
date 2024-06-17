using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Program
    {
        public static int codcliente = 0, codconta = 0;
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Conta> Contas = new List<Conta>();

        public static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            bool sair = true;
            while (sair)
            {
                Console.WriteLine("1-Gerenciar CLIENTES");
                Console.WriteLine("2-Gerenciar CONTAS");
                Console.WriteLine("3-SAIR");
                Console.Write("Opção: ");
                int escolha = Leri();

                switch (escolha)
                {
                    case 1:
                        MenuCliente();
                        break;
                    case 2:
                        MenuConta();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Erro! Opção inválida.");
                        break;
                }
            }
        }

        static void MenuCliente()
        {
            Console.WriteLine("1-Cadastrar CLIENTE");
            Console.WriteLine("2-Consultar CLIENTE");
            Console.WriteLine("3-Remover CLIENTE");
            Console.WriteLine("4-Atualizar CLIENTE");
            Console.WriteLine("5-Voltar ao MENU INICIAL");
            Console.Write("Opção: ");
            int escolha = Leri();
            switch (escolha)
            {
                case 1:
                    CreateCliente();
                    break;
                case 2:
                    ConsultaCliente();
                    break;
                case 3:
                    ApagarCliente();
                    break;
                case 4:
                    AttCliente();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Erro! Opção inválida.");
                    break;
            }
        }

        static void MenuConta()
        {
            Console.WriteLine("1 - Criar CONTA para um CLIENTE");
            Console.WriteLine("2 - Sacar dinheiro de uma CONTA de um CLIENTE");
            Console.WriteLine("3 - Depositar dinheiro para uma CONTA de um CLIENTE");
            Console.WriteLine("4 - Verificar saldo de uma CONTA de um CLIENTE");
            Console.WriteLine("5 - Transferir dinheiro de uma CONTA de um CLIENTE para outro CLIENTE");
            Console.WriteLine("6 - Voltar ao MENU INICIAL");
            Console.Write("Opção: ");
            int escolha = Leri();
            switch (escolha)
            {
                case 1:
                    CriarConta();
                    break;
                case 2:
                    Sacar();
                    break;
                case 3:
                    Depositar();
                    break;
                case 4:
                    VerificarSaldo();
                    break;
                case 5:
                    Transferir();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Erro! Opção inválida.");
                    break;
            }
        }

        public static void CreateCliente()
        {
            Console.Write("Informe o CPF: ");
            string cpf = Lers();
            Console.Write("Informe o nome: ");
            string nome = Lers();
            string convert = codcliente++.ToString();

            Cliente cliente = new Cliente(cpf, nome, convert);
            Clientes.Add(cliente);
        }

        public static Cliente ConsultaCliente()
        {
            Console.Write("Digite o CPF do cliente: ");
            string idcliente = Lers();

            Cliente cliente = Clientes.FirstOrDefault(c => c.Cpf == idcliente);

            if (cliente != null)
            {
                Console.WriteLine("Nome: " + cliente.Nome);
                if (cliente.Conta != null)
                {
                    Console.WriteLine("Conta ID: " + cliente.Conta.Idconta);
                    Console.WriteLine("Saldo: R$ " + cliente.Conta.Saldo);
                    Console.WriteLine("Codigo: " + codconta);
                }
                else
                {
                    Console.WriteLine("O cliente ainda não possui uma conta.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            return cliente;
        }

        public static void ApagarCliente()
        {
            Cliente remover = ConsultaCliente();
            Clientes.Remove(remover);
        }

        public static void AttCliente()
        {
            Cliente atualizar = ConsultaCliente();
            if (atualizar != null)
            {
                Console.Write("Digite o novo nome do cliente: ");
                string nome = Lers();
                Console.Write("Digite o novo código do cliente: ");
                string idC = Lers();

                atualizar.Nome = nome;
                atualizar.Codcliente = idC;
            }
        }

        public static void CriarConta()
        {
            if (Clientes.Any())
            {
                Console.Write("Informe o CPF do cliente que utilizará esta conta: ");
                string idconta = Lers();
                Console.Write("Informe o saldo da conta: ");
                double saldo = Lerd();

                Conta conta = new Conta(++codconta, saldo);
                Contas.Add(conta);
                Console.WriteLine("Conta criada código: " + codconta);
                Console.WriteLine("Saldo: " + saldo);

                Clientes.FirstOrDefault(c => c.Cpf == idconta)?.AddConta(conta);
            }
            else
            {
                Console.WriteLine("Crie um cliente antes de criar uma conta.");
                CreateCliente();
            }
        }

        public static void Sacar()
        {
            Cliente csaque = ConsultaCliente();
            if (csaque != null)
            {
                Console.Write("Digite o valor a ser sacado: ");
                double valor = Lerd();

                csaque.Conta.Sacar(valor);
            }
        }

        public static void Depositar()
        {
            Cliente cdeposito = ConsultaCliente();
            if (cdeposito != null)
            {
                Console.Write("Digite o valor a ser depositado: ");
                double valor = Lerd();

                cdeposito.Conta.Depositar(valor);
            }
        }

        public static void VerificarSaldo()
        {
            Cliente cdeposito = ConsultaCliente();
        }

        public static void Transferir()
        {
            if (Clientes.Count > 1)
            {
                Cliente primeiro = ConsultaCliente();

                Console.WriteLine("Digite o valor que será sacado por " + primeiro.Nome);
                double valor = Lerd();

                Cliente segundo = ConsultaCliente();

                if (primeiro.Conta.Saldo < valor || valor <= 0)
                {
                    Console.WriteLine("Saldo insuficiente na conta de " + primeiro.Nome);
                    return;
                }

                segundo.Conta.Depositar(valor);

                Console.WriteLine("Transferência realizada com sucesso");
            }
            else
            {
                Console.WriteLine("Crie outro Cliente antes de fazer uma transferência");
            }
        }


        public static string Lers()
        {
            return Console.ReadLine();
        }

        public static int Leri()
        {
            return int.Parse(Lers());
        }

        public static double Lerd()
        {
            return double.Parse(Lers());
        }
    }

    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Codcliente { get; set; }
        public Conta Conta { get; set; }

        public Cliente(string cpf, string nome, string codcliente)
        {
            Cpf = cpf;
            Nome = nome;
            Codcliente = codcliente;
        }

        public void AddConta(Conta conta)
        {
            Conta = conta;
        }
    }

    public class Conta
    {
        public int Idconta { get; set; }
        public double Saldo { get; set; }

        public Conta(int idconta, double saldo)
        {
            Idconta = idconta;
            Saldo = saldo;
        }

        public void Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine("Depósito realizado com sucesso.");
        }
    }
}
