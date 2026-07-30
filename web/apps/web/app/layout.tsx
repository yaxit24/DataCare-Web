import './globals.css';

export const metadata = {
  title: 'DataCareNext',
  description: 'DataCareNext jewellery ERP — web',
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  );
}
