using System;
using TransferenciasBancarias;

namespace TransferenciasBancarias
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito*-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo Atual da Conta de {0} é {1}", this.Nome, this.Saldo);

            return true;

        }

        public void Deposito(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo Atual da Conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferido, Conta contaDestino)
        {
            if(this.Sacar(valorTransferido))
            {
                contaDestino.Deposito(valorTransferido);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }

    }
}
