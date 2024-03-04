#!/bin/bash

# Install client side dependencies
(cd NucleicAcidConverter.Client && npm i)
echo "Client side dependencies installed successfully"

# Install server side dependencies
(cd NucleicAcidConverter && dotnet restore)
echo "Server side dependencies installed successfully"
