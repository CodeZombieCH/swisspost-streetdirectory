#!/bin/bash
echo "Processing file '$1' ..."
if [ ! -f $1 ]; then
    echo "File not found!"
    exit 1
fi

utf8_file_name=${1##*/}
utf8_file_name="$(dirname $1)/${utf8_file_name%.csv}.utf8.csv"
echo "Writing to file '$utf8_file_name' ..."

iconv -c -f ISO-8859-1 -t utf-8 $1 > $utf8_file_name

echo "Done"
