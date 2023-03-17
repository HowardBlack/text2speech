String instatus;
void setup()
{
    Serial.begin(9600);    
    pinMode(13, OUTPUT);
    pinMode(12, OUTPUT);
    pinMode(11, OUTPUT);
    pinMode(2, INPUT);
    pinMode(3, INPUT);
    pinMode(4, INPUT);
}


void loop()
{
  Serial.println("A"+String(digitalRead(2))+"B"+String(digitalRead(3))+"C"+String(digitalRead(4)));
      
  // Serial.println(switchStatus);
    if (Serial.available() > 0)
    {
        char inByte = Serial.read();
        switch (inByte)
        {
            case '0':
                digitalWrite(13, LOW);
                delay(1000);
                break;
            case '1':
                digitalWrite(13, HIGH);
                delay(1000);
                break;
            case '2':
                digitalWrite(12, LOW);
                delay(1000);
                break;
            case '3':
                digitalWrite(12, HIGH);
                delay(1000);
                break;
            case '4':
                digitalWrite(11, LOW);
                delay(1000);
                break;
            case '5':
                digitalWrite(11, HIGH);
                delay(1000);
                break;
            default:
                digitalWrite(12, LOW);
                digitalWrite(13, LOW);
        }
    }
       //instatus=String(digitalRead(2));
 delay(50);
      
}
