#!/bin/sh
#!/usr/bin/env bash
which sh
cd /var/
mkdir projects
cd projects
git clone https://github.com/Lev4and/HeadHunter.git
cd HeadHunter
git reset --hard origin/master
rm .env
cp .env.dist .env
export $(egrep -v '^#' .env | xargs -0)
docker-compose stop
docker rm -vf $(docker ps -aq)
docker rmi -f $(docker images -aq)
docker-compose ps
docker-compose images
docker ps
docker images
docker volume create portainer_data
docker volume create grafana_data
docker-compose up -d --build
chown -R 472:472 portainer_data
chown -R 472:472 grafana_data
docker-compose ps
docker-compose restart
docker-compose ps