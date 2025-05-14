#!/bin/bash

set -e  # 에러 발생 시 종료

OS_NAME=$(uname)

if [[ "$OS_NAME" == "Darwin" ]]; then
    echo "🔧 Detected macOS"
    DEFINE="OSX"
elif [[ "$OS_NAME" == "Linux" ]]; then
    echo "🔧 Detected Linux"
    DEFINE="LINUX"
else
    echo "❌ Unsupported OS: $OS_NAME"
    exit 1
fi

dotnet build -c Debug -p:DefineConstants=$DEFINE
