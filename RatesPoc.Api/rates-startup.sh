#!/bin/sh

# Surface Vault mount as environment variables
secretFile="/vault/secrets/secret.env"

if [[ -f "$secretFile" ]]; then

    echo "Detected secret file $secretFile, loading values as environment variables"

    set -o allexport
    source $secretFile
    set +o allexport
fi

# Run the Rates app
dotnet RatesPoc.Api.dll