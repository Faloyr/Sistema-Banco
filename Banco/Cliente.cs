using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Cliente
    {
        private string cpf;
        private string nome;
        private Conta conta;
        private string codcliente;

        public Cliente(string cpf, string nome, string codcliente)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.codcliente = codcliente;
        }

        public string GetCpf()
        {
            return cpf;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Conta GetConta()
        {
            return conta;
        }

        public void SetConta(Conta conta)
        {
            this.conta = conta;
        }

        public string GetCodcliente()
        {
            return codcliente;
        }

        public void SetCodcliente(string codcliente)
        {
            this.codcliente = codcliente;
        }

        public void AddConta(Conta conta)
        {
            this.conta = conta;
        }
    }

