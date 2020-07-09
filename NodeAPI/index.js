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
    request.query('select * from llaves', (err, record) => {
      if (err) console.log(err)
      res.json(record)
    })
  })
  // res.json([req.params.code, req.params.edificio])
})
