# Multi-stage build for the DataCareNext API (right-sized; ADR-0002).
# Stage 1: build the monorepo workspace (pnpm + turbo), emit apps/api/dist.
FROM node:24-slim AS build
RUN corepack enable
WORKDIR /repo
COPY pnpm-workspace.yaml package.json pnpm-lock.yaml turbo.json tsconfig.base.json ./
COPY packages ./packages
COPY apps ./apps
RUN pnpm install --frozen-lockfile
# Generate the Prisma client before compiling packages that import it; generation failures stop the image.
RUN pnpm --filter @datacare/db db:generate
RUN pnpm build

# Stage 2: slim runtime — only what the API needs.
FROM node:24-slim AS runtime
ENV NODE_ENV=production
WORKDIR /app
RUN corepack enable
# copy built workspace (dist + node_modules resolved by pnpm)
COPY --from=build /repo /repo
WORKDIR /repo/apps/api
EXPOSE 3000
# non-root
USER node
# server.ts boots buildApp({prisma, secret}) and listens on PORT (default 3000)
CMD ["node", "dist/server.js"]
