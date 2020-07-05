/*
  WiFiEsp example: WebClient

  This sketch connects to google website using an ESP8266 module to
  perform a simple web search.

  For more details see: http://yaab-arduino.blogspot.com/p/wifiesp-example-client.html
*/

#include "WiFiEsp.h"

// Emulate Serial1 on pins 6/7 if not present
#ifndef HAVE_HWSERIAL1
#include "SoftwareSerial.h"
SoftwareSerial Serial1(6, 7); // RX, TX
#endif

#include <usbhid.h>
#include <usbhub.h>
#include <hiduniversal.h>
#include <hidboot.h>
#include <SPI.h>




class MyParser : public HIDReportParser {
  public:
    MyParser();
    void Parse(USBHID *hid, bool is_rpt_id, uint8_t len, uint8_t *buf);
  protected:
    uint8_t KeyToAscii(bool upper, uint8_t mod, uint8_t key);
    uint8_t OnKeyScanned(bool upper, uint8_t mod, uint8_t key);
    virtual void OnScanFinished();
};

char code[100];
int index = 0;

char ssid[] = "MMarelli Fibertel 2.4GHz";            // your network SSID (name)
char pass[] = "gainza2021";        // your network password
int status = WL_IDLE_STATUS;     // the Wifi radio's status

char server[] = "us-central1-qdoor-84a66.cloudfunctions.net";


// Initialize the Ethernet client object
WiFiEspClient client;

MyParser::MyParser() {}

void MyParser::Parse(USBHID *hid, bool is_rpt_id, uint8_t len, uint8_t *buf) {
  // If error or empty, return
  //  for (uint8_t i = 0; i < 8; i++) {
  //    Serial.print(buf[i]);
  //    Serial.print(" ");
  //  }
  //  Serial.println();

  if (buf[2] == 1 || buf[2] == 0) return;

  for (uint8_t i = 7; i >= 2; i--) {
    // If empty, skip
    if (buf[i] == 0) continue;

    // If enter signal emitted, scan finished
    if (buf[i] == UHS_HID_BOOT_KEY_ENTER) {
      code[index] = '\0';
//      for (int j = 0; j < index; j++) Serial.print((char)code[j]);
//      Serial.println();
      index = 0;
      OnScanFinished();
    }

    // If not, continue normally
    else {
      // If bit position not in 2, it's uppercase words
      code[index] = OnKeyScanned(buf[0] == 32, buf, buf[i]);
      //      Serial.println((char)code[index]);
      index++;
    }

    return;
  }
}

uint8_t MyParser::KeyToAscii(bool upper, uint8_t mod, uint8_t key) {
  // Letters
  if (VALUE_WITHIN(key, 0x04, 0x1d)) {
    if (upper) return (key - 4 + 'A');
    else return (key - 4 + 'a');
  }

  // Numbers
  else if (VALUE_WITHIN(key, 0x1e, 0x38)) {
    if (upper) return (key + 7);
    else return ((key == UHS_HID_BOOT_KEY_ZERO) ? '0' : key - 0x1e + '1');
  }

  return 0;
}

uint8_t MyParser::OnKeyScanned(bool upper, uint8_t mod, uint8_t key) {
  uint8_t ascii = KeyToAscii(upper, mod, key);
  return ascii;
}

void MyParser::OnScanFinished() {
  Serial.println("SCANED");
  String edificioId = "yA74O4JWV2z4ylopqpGE";
  String codigo = code;
  Serial.println("Starting connection to server...");
  // if you get a connection, report back via serial
  if (client.connect(server, 80)) {
      Serial.println("Connected to server");
    // Make a HTTP request

    client.println("GET /api/ingresar/" + codigo + "/" + edificioId + " HTTP/1.1");
    client.println("Host: us-central1-qdoor-84a66.cloudfunctions.net");
    client.println("Connection: keep-alive");
    client.println();
  }
 // Serial.println(" - Finished");
}

USB          Usb;
USBHub       Hub(&Usb);
HIDUniversal Hid(&Usb);
MyParser     Parser;

void setup()
{
  pinMode(A0,OUTPUT);
  digitalWrite(A0,HIGH);

  // initialize serial for debugging
  Serial.begin(115200);
  // initialize serial for ESP module
  Serial1.begin(9600);
  // initialize ESP module
  WiFi.init(&Serial1);

  Serial.println("Start");
  if (Usb.Init() == -1) {
    Serial.println("OSC did not start.");
  }


  delay( 200 );

  Hid.SetReportParser(0, &Parser);

  // check for the presence of the shield
  if (WiFi.status() == WL_NO_SHIELD) {
    Serial.println("WiFi shield not present");
    // don't continue
    while (true);
  }

  // attempt to connect to WiFi network
  while ( status != WL_CONNECTED) {
    //Serial.print("Attempting to connect to WPA SSID: ");
    //Serial.println(ssid);
    // Connect to WPA/WPA2 network
    status = WiFi.begin(ssid, pass);
  }

  // you're connected now, so print out the data
  //Serial.println("You're connected to the network");
  client.connect(server, 80);
  //Serial.println("Connected client");
  printWifiStatus();
  Serial.println("Listo para escanear bebe");


}

char c;
int valorenc = 0;
int times = 0;

void loop()
{
  
  //digitalWrite(3,HIGH);
  //if there are incoming bytes available
  //from the server, read them and print them
  valorenc = 0;
  Usb.Task();


  while (client.available()) {
    c = client.read();
//    Serial.write(c);
    //Serial.print(c);
    valorenc = 1;
  }

  

  if (valorenc == 1){
    if (c == '1') {
      //encender relay 1 
      digitalWrite(A0,LOW);
      Serial.println("SE ABRE LA PUERTA");

      delay(6000);
      digitalWrite(A0,HIGH);

    }
      client.flush();
      client.stop();
      //times ++;
      
  }

}


void printWifiStatus()
{
  // print the SSID of the network you're attached to
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print your WiFi shield's IP address
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);

  // print the received signal strength
  long rssi = WiFi.RSSI();
  Serial.print("Signal strength (RSSI):");
  Serial.print(rssi);
  Serial.println(" dBm");
}
