//Programa: Teste Acelerometro MMA7361

#include <AcceleroMMA7361.h>

AcceleroMMA7361 accelero;
int x = 0;
int y = 1;
int z = 2;

int mapx = 0;
int mapy = 0;
int mapz = 0;

int calX = 18;
int calY = 14;
int zaxis;

void setup(){
  delay(500);
  Serial.begin(9600);
  accelero.begin(13, 12, 11, 10, A0, A1, A2);
  //Seta a voltagem de referencia AREF como 3.3v
  accelero.setARefVoltage(3.3);
  //Seta a sensibilidade (Pino GS) para +/-6G
  accelero.setSensitivity(LOW);
  accelero.calibrate();
  delay(500);
  Serial.println();
  Serial.println("OK");
  
}

void loop(){
 
 // Serial.flush(); //Empty the memory each time in the loop
  
  mapx = accelero.getXAccel();
  Serial.print(mapx);
  Serial.print(",");
  
  Serial.print(accelero.getYAccel());
  Serial.print(",");
  
  zaxis = map(analogRead(z),270,402,0,1000);
  
  if(zaxis < 800 || zaxis > 1200){Serial.print(1);}
  else{Serial.print(0);}
  Serial.println();
  delay(100);
  
  
  //x = accelero.getXAccel(); //Obtem o valor do eixo x
  //y = accelero.getYAccel(); //Obtem o valor do eixo y
  //z = accelero.getZAccel(); //Obtem o valor do eixo z
  
}
