const functions = require('firebase-functions');
const express = require('express')
const db = require('mssql')

const config = {
  user: "pabloPaez_SQLLogin_1",
  password: "uybcgw4ho1",
  server: "Sesamodb.mssql.somee.com",
  database: "Sesamodb"
}

const app = express()
const api = express()


api.use("/", app)

// app.listen(8000, () => {
//   console.log("Server running in port 8000")
// })

app.get('/connect', (req, res) => res.send("Connected to server!"))

app.get('/', (req, res) => {
  let Today = new Date()
  let Day = Today.getDay()
  let Mounth = Today.getMonth()
  let Year = Today.getFullYear()
  let Time = Today.getHours()
  res.json(Mounth + "/" + Day + "/" + Year + " " + Time)
})

app.get('/ingresar/:code/:edificio', (req, res) => {
  db.connect(config, (error) => {
    if (error) {
      console.log("ERROR!")
      console.log(error)
    }
    let request = new db.Request()
    request.query(`Declare @resultado int
                   Execute @resultado = validarIngreso @code = '${req.params.code}', @idEdificio = ${parseInt(req.params.edificio)};
                   Select @resultado`, (err, record) => {
      if (err) console.log(err)
      res.json(record["recordset"][0][""])
    })
    // res.json([req.params.code, req.params.edificio])
  })
})

exports.api = functions.https.onRequest(api);

// // Create and Deploy Your First Cloud Functions
// // https://firebase.google.com/docs/functions/write-firebase-functions
//
// exports.helloWorld = functions.https.onRequest((request, response) => {
//   functions.logger.info("Hello logs!", {structuredData: true});
//   response.send("Hello from Firebase!");
// });
