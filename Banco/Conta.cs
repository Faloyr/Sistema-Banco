using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Conta
    {
        private int idconta;
        private double saldo;

        public Conta(int idconta, double saldo)
        {
            this.idconta = idconta;
            this.saldo = saldo;
        }

        public int GetIdconta()
        {
            return idconta;
        }

        public double GetSaldo()
        {
            return saldo;
        }

        public bool Sacar(double saque)
        {
            bool fim;
            if (saque <= saldo && saque > 0)
            {
                this.saldo -= saque;
                Console.WriteLine("Saque realizado com sucesso");
                Console.WriteLine("Saldo atual: " + GetSaldo());
                fim = true;
            }
            else
            {
                Console.WriteLine("Saque não pode ser realizado");
                fim = false;
            }
            return fim;
        }

        public void Depositar(double deposito)
        {
            if (deposito > 0)
            {
                this.saldo += deposito;
                Console.WriteLine("Depósito realizado com sucesso");
                Console.WriteLine("Saldo atual: " + GetSaldo());
            }
            else
            {
                Console.WriteLine("Erro");
            }
        }
    }


