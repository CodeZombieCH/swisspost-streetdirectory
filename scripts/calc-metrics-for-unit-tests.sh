#!/bin/bash
echo "Processing file '$1' ..."
if [ ! -f $1 ]; then
    echo "File not found!"
    exit 1
fi

declare -a types=("00" "01" "02" "03" "04" "05" "06" "07" "08" "12")

for i in "${types[@]}"
do
    lines=$(awk "/^$i;/ {print}" $1 | wc -l | awk '{print $1}')
    echo "$i: $lines"
done

echo "Done"
