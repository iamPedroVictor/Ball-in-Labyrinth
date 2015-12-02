#include <LiquidCrystal.h>

LiquidCrystal lcd(12,11,5,4,3,2);
int incomingByte, x, y, oldByte;
String text;


void setup(){
  lcd.begin(16,2);
  Serial.begin(9600);
}

void loop(){
  if(Serial.available() > 0){
    incomingByte = Serial.read();
    if(oldByte != incomingByte){
      if(incomingByte == 108){
        lcd.clear();
        lcd.print("Esta Longe");
      }else{
        if(incomingByte == 112){
          lcd.clear();
          lcd.print("Esta Perto");
        }
      }
      delay(100);
      oldByte = incomingByte;
    }
    /*lcd.print(char(incomingByte));
    x = x + 1;
    if(x > 6){
      lcd.setCursor(0,0);
      delay(200);
      lcd.clear();
      x = 0;
    }*/
  }
}
