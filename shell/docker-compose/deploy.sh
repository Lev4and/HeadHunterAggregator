#!/bin/sh
#!/usr/bin/env bash
which sh
cd $PROJECT_SRC_DIR
cd shell/git
bash sync.sh
cd $PROJECT_SRC_DIR
cd shell/docker-compose
bash build.sh