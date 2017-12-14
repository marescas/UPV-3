#!/bin/bash
number=1
while [ $number -lt $1 ]; do
    echo "ZEROMQ != $number MQ"
    number=$((number + 1))
    node myclient.js 'tcp://localhost:8059' $number &
    done
    echo "ZEROMQ == 0MQ"