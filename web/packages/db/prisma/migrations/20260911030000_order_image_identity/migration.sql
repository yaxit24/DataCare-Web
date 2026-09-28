-- Full saved order image identity includes year, book, hidden voucher and design.
-- Widen only; existing image keys and bytes retain their original ownership.
ALTER TABLE "ENTITY_IMAGE" ALTER COLUMN "ENTITY_KEY" TYPE VARCHAR(255);
