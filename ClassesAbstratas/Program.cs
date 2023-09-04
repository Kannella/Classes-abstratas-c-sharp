/*
Classes abstratas
• São classes que não podem ser instanciadas
• É uma forma de garantir herança total: somente subclasses não
abstratas podem ser instanciadas, mas nunca a superclasse abstrata
• Ou seja, só posso instanciar objetos do tipo das subclasses não abstratas

Exemplo
Suponha que em um negócio relacionado a banco, apenas
contas poupança e contas para empresas são permitidas.
Não existe conta comum.

Para garantir que contas comuns não possam ser
instanciadas, basta acrescentarmos a palavra "abstract" na
declaração da classe.

namespace Course {
abstract class Account {
(...)

Notação UML: itálico
*/

using System;
using System.Diagnostics;
using System.Security.Principal;
using Course.Entities;

namespace Course {
    class Program {
        static void Main(string[] args) {
            Account acc = new Account(1001, "Alex", 0.0); // vai dar erro pois a classe Account é abstract e assim portanto não pode ser instanciada
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            // UPCASTING

            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Anna", 0.0, 0.01);

            // DOWNCASTING

            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(100.0);

            // BusinessAccount acc5 = (BusinessAccount)acc3;
            if (acc3 is BusinessAccount) {
                //BusinessAccount acc5 = (BusinessAccount)acc3;
                BusinessAccount acc5 = acc3 as BusinessAccount;
                acc5.Loan(200.0);
                Console.WriteLine("Loan!");
            }

            if (acc3 is SavingsAccount) {
                //SavingsAccount acc5 = (SavingsAccount)acc3;
                SavingsAccount acc5 = acc3 as SavingsAccount;
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }
        }
    }
}