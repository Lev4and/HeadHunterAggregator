#!/bin/sh
#!/usr/bin/env bash
which sh
cd $PROJECT_SRC_DIR
docker volume create grafana_data
chown -R 472:472 grafana_data