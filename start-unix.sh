#!/bin/bash

cd estagioja_angular_webapp && npm install && ng build --configuration production && cd .. && docker-compose up -d