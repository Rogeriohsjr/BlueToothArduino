# BlueToothArduino
C# that sends a command to a Arduino Bluetooth Shield. I am using https://github.com/inthehand/32feet to connect to the Arduino shield.


<b>Bluetooth Shield v1.0</b><br>
https://www.elecrow.com/wiki/index.php?title=Bluetooth_Shield_v1.0

<b>inthehand/32feet</b><br>
https://github.com/inthehand/32feet


# Arduino Code - Slave
```

/* Upload this sketch into Crowduino and press reset*/
 
#include <SoftwareSerial.h>   //Software Serial Port
#include <Servo.h>
#define RxD 6
#define TxD 7
 
SoftwareSerial objBlueToothSerial(RxD,TxD);
Servo objServo;
int iServoAngle = 10;
void setup() 
{ 
  Serial.begin(9600);
  pinMode(RxD, INPUT);
  pinMode(TxD, OUTPUT);
  setupBlueToothConnection(); 
  objServo.attach(8);
  objServo.write(iServoAngle);
} 
 
void loop() 
{ 
  char recvChar;
  bool bPrint = false;
  String sWord = "";
  while(1){
    
    if(objBlueToothSerial.available()){//check if there's any data sent from the remote bluetooth shield
      recvChar = objBlueToothSerial.read();
      sWord += recvChar;
      bPrint = false;
      
    } else if(Serial.available()){//check if there's any data sent from the local serial terminal, you can add the other applications here
      recvChar  = Serial.read();
      sWord += recvChar;
      bPrint = false;
    }
    else{
      bPrint = true;
    }

    if(bPrint && sWord != ""){
      Serial.print("Result[");
      Serial.print(sWord);
      Serial.print("]");
      Serial.println("");
      sWord = "";
      bPrint = false;
      DoIt(sWord);
    }
  }
}

 void DoIt(String pCommand)
 {
    if(pCommand == "1"){
      objServo.write(iServoAngle);
    }
    else{
      objServo.write(iServoAngle + 10);
    }
    
 }
void setupBlueToothConnection()
{
  objBlueToothSerial.begin(38400); //Set BluetoothBee BaudRate to default baud rate 38400
  //blueToothSerial.begin(9600);
  
  objBlueToothSerial.print("\r\n+STWMOD=0\r\n"); //set the bluetooth work in slave mode
  objBlueToothSerial.print("\r\n+STNA=RogerioArduinoBlooth\r\n"); //set the bluetooth name as "CrowBTSlave"
  objBlueToothSerial.print("\r\n+STPIN=0000\r\n");//Set SLAVE pincode"0000"
  objBlueToothSerial.print("\r\n+STOAUT=1\r\n"); // Permit Paired device to connect me
  objBlueToothSerial.print("\r\n+STAUTO=0\r\n"); // Auto-connection should be forbidden here
  delay(2000); // This delay is required.
  objBlueToothSerial.print("\r\n+INQ=1\r\n"); //make the slave bluetooth inquirable 
  Serial.println("The slave bluetooth is inquirable!");
  delay(2000); // This delay is required.
  objBlueToothSerial.flush();
}

```
