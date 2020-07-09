const express = require('express')
const db = require('mssql')

const config = {
  user: "pabloPaez_SQLLogin_1",
  password: "uybcgw4ho1",
  server: "Sesamodb.mssql.somee.com",
  database: "Sesamodb"
}

const app = express()


app.listen(8000, () => {
  console.log("Server running in port 8000")
})

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
                   Execute @resultado = validarIngresoBeta @code = '${req.params.code}', @idEdificio = ${parseInt(req.params.edificio)};
                   Select @resultado`, (err, record) => {
      if (err) console.log(err)
      res.json(record["recordset"][0][""])
    })
    // res.json([req.params.code, req.params.edificio])
  })
})
