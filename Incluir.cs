using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Tp3;
using System.Linq.Expressions;

public class Incluir{

public string peso; 
public String checarCondicao;
public int idade;
public DateTime dia;
public String Nome;
public List<String> minhaLista = new List <String>();
String respost; 
int i;
string kg = "kg";

public void exibirInput(){

do{ 

Console.WriteLine("[1] para Cadastrar [2] Para checar dados cadastrados [3] Para sair do programa.");
String respost = Console.ReadLine();

switch(respost){

    case "1":

    ComecarCadastro();
    break;

    case "2":

    Acessar_Dados_Pacientes_Lista();
    break;

    case "3":

    Console.WriteLine("Obrigado por utilizar o programa.");
    return;
    
    default:

    Console.WriteLine("Entrada desconhecida.");
    Thread.Sleep(1000);
    Console.Clear();
    break;
}
  }
      while(respost != "3");
}

//Para começar de fato o cadastro para o usuario colocar os dados.

public void ComecarCadastro(){

    Console.WriteLine("Insira o Nome do Bicho");
    this.Nome  = Convert.ToString(Console.ReadLine().ToString());

    Console.WriteLine("Insira a data de nascimento do bicho");
     this.dia = Convert.ToDateTime((Console.ReadLine()));

    Console.WriteLine("Insira a  idade do bicho");
    this.idade = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("O Animal esta saudavel?");
     this.checarCondicao = Console.ReadLine();

    if(checarCondicao == "sim" || checarCondicao == "Sim" || checarCondicao == "SIM" ){

        checarCondicao = "Saudavel";
    }
    else {
        Guid gerarID_Unico = Guid.NewGuid();
       
        checarCondicao = $"Necessário marcar uma consulta com o veterinário, apresente, no dia da consulta, este ID a recepcionista: {gerarID_Unico}"; 
    }

    Console.WriteLine("Escreva o peso do animal");
    this.peso = Console.ReadLine();

}

public void Acessar_Dados_Pacientes_Lista(){

string pesoConvertido = Convert.ToString(peso);
string idadeConvertida = Convert.ToString(idade);
string dataConvertida = Convert.ToString(dia);

minhaLista.Add(this.Nome);
minhaLista.Add(this.checarCondicao);
minhaLista.Add(idadeConvertida);
minhaLista.Add(peso);
minhaLista.Add(dataConvertida);

FileStream f = new FileStream("DadosConsulta.txt", FileMode.OpenOrCreate);

StreamWriter arquivar = new StreamWriter(f);

foreach(string element in minhaLista){

if(element == Nome){

    arquivar.WriteLine("Nome do animal: " + this.Nome);
}
else if(element == pesoConvertido){

  arquivar.WriteLine("Peso: " + element + "Kg");

}

else if(element == dataConvertida){

    arquivar.WriteLine("Data de nascimento: " + element);
}

else if(element == idadeConvertida ){

    arquivar.WriteLine("Idade do animal: " + element);
}

else if(element == checarCondicao){

    arquivar.WriteLine("Condição do animal: " + element);
}
   }

     Console.WriteLine(" ");

     Console.WriteLine("Escrito no banco de dados consta: ");

     Console.WriteLine(" ");
   
     Console.WriteLine($"Nome: {Nome} || Idade: {idadeConvertida} || Peso: {peso}{kg}  || Ano de Nascimento: {dataConvertida} || Estado de Saude: {checarCondicao}");

   arquivar.Close();
   f.Close();
 
  }
}
