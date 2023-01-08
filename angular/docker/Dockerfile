FROM node:16.13.0-alpine as builder
COPY . /app
WORKDIR /app
RUN npm install
RUN npm run build

FROM nginx:1.17.10-alpine
EXPOSE 80

COPY ./docker/nginx.conf /etc/nginx/nginx.conf
COPY --from=builder /app/dist/angular /usr/share/nginx/html
