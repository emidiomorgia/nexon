# Step 1: Build the Angular app
FROM node:22 AS build

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the app files
COPY . .

# Build the Angular app in production mode
RUN npm run build --prod

# Step 2: Serve the app with nginx
FROM nginx:alpine

# Copy the built Angular app from the previous stage
COPY --from=build /app/dist/nexon/browser /usr/share/nginx/html

# Copy nginx configuration file (optional, for custom configuration)
# COPY nginx.conf /etc/nginx/nginx.conf

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
