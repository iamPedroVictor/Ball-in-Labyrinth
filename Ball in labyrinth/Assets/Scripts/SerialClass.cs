using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SerialClass : MonoBehaviour {
	private	int	speed;
	private	string	nameCom;
	private	SerialPort	stream;

	
	public SerialClass(string portName, int portSpeed){
		//Construtor da Classe
		nameCom	= portName;
		speed	= portSpeed;
		portConstruct();

	}

	private void portConstruct(){
		//Cria a porta para ser utilizada durante o projeto.
		stream = new SerialPort(nameCom,speed);
		if(stream.IsOpen){
			stream.Close();
			StartCoroutine(pauseTime(0.2f));
			stream.Open();
		}else{
			stream.Open();
		}
	}

	public string serialPortRead(){
		//Realiza a leitura da porta serial
		//Retornando uma string.
		string infoRead;
		infoRead = stream.ReadLine();
		return infoRead;
	}

	public void closePort(){
		stream.Close();
	}

	private IEnumerator pauseTime(float timeNeed){
		yield return new WaitForSeconds(timeNeed);
	}

	public string digitalRead(string digitalPort){
		//Busca a leitura da porta digital passada pelo argumento
		stream.Write("DP " + digitalPort);
		while(!checkSerialOk()){
			StartCoroutine(pauseTime(0.15f));
		}
		string info = stream.ReadLine();
		return info;
	}
	

	public string analogicRead(string analogicPort){
		//Busca a leitura da porta analogica passada pelo argumento
		stream.Write("AN "+ analogicPort);
		while(!checkSerialOk()){
			StartCoroutine(pauseTime(0.15f));
		}
		string info = stream.ReadLine();
		return info;
	}
	
	private void clearSerial(){
		//Pedi para fazer uma limpeza na porta serial
		stream.Write("Clear");
	}

	private bool checkSerialOk(){
		//Faz uma leitura na porta serial
		//Se for comunicado que esta ok, retorna como verdadeira
		//Se nao fica como falsa
		string infoRead;
		infoRead = stream.ReadLine();
		if(infoRead == "Ok"){
			return true;
		}else{
			return false;
		}
	}

}
