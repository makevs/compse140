# Base Dockerfile sourced from:
# https://elysiajs.com/patterns/deployment.html#docker
# Adjustments have been made as necessary to fit the project requirements.

FROM oven/bun:1 AS build

WORKDIR /app

# Cache packages installation
COPY package.json package.json
COPY bun.lockb bun.lockb

RUN bun install

COPY ./src ./src

ENV NODE_ENV=production

RUN bun build \
	--compile \
	--minify-whitespace \
	--minify-syntax \
	--target bun \
	--outfile server \
	./src/index.ts

FROM debian:bullseye

RUN apt-get update && \
    apt-get install -y \
    libc6 \
    libstdc++6 \
    procps && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY --from=build /app/server server

ENV NODE_ENV=production

CMD ["./server"]

EXPOSE 3000