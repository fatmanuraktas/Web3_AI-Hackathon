const express = require('express');
const cors = require('cors');


const gamechat = require('./gamechat');
require('dotenv').config();


const app = express();
const port = process.env.PORT || 3200;

app.use(cors());
app.use(express.json());

app.use('/', gamechat);

app.listen(port, () => {
    console.log(`Server is running at http://localhost:${port}`);
});
