#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p bb3f5119-e73d-4754-bfec-9ecea97bdc8f -t
    fi
    cd ../
fi

docker-compose up -d
