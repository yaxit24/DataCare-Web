// Native PDF raster QA fallback for macOS hosts without Poppler. Draw the PDF page directly:
// PDFKit thumbnail caching can omit glyphs even when the PDF is complete.
import Foundation
import AppKit
import CoreGraphics
import PDFKit

let root = URL(fileURLWithPath: CommandLine.arguments[1], isDirectory: true)
let output = root.appendingPathComponent("pdf-raster", isDirectory: true)
try FileManager.default.createDirectory(at: output, withIntermediateDirectories: true)
let files = try FileManager.default.contentsOfDirectory(at: root, includingPropertiesForKeys: nil)
    .filter { $0.pathExtension == "pdf" }.sorted { $0.lastPathComponent < $1.lastPathComponent }
for file in files {
    guard let document = CGPDFDocument(file as CFURL), let textDocument = PDFDocument(url: file) else {
        fatalError("Cannot read \(file.lastPathComponent)")
    }
    let name = file.deletingPathExtension().lastPathComponent
    print("\(file.lastPathComponent): \(document.numberOfPages) PDF pages")
    try (textDocument.string ?? "").write(to: output.appendingPathComponent(name + ".txt"), atomically: true, encoding: .utf8)
    for index in 1...document.numberOfPages {
        guard let page = document.page(at: index) else { fatalError("Missing PDF page") }
        let rect = page.getBoxRect(.mediaBox)
        let scale: CGFloat = 2
        let width = Int(rect.width * scale), height = Int(rect.height * scale)
        guard let context = CGContext(data: nil, width: width, height: height, bitsPerComponent: 8,
            bytesPerRow: width * 4, space: CGColorSpaceCreateDeviceRGB(),
            bitmapInfo: CGImageAlphaInfo.premultipliedLast.rawValue) else { fatalError("Cannot create PDF bitmap") }
        context.setFillColor(CGColor(gray: 1, alpha: 1))
        context.fill(CGRect(x: 0, y: 0, width: width, height: height))
        context.scaleBy(x: scale, y: scale)
        context.drawPDFPage(page)
        guard let image = context.makeImage(), let png = NSBitmapImageRep(cgImage: image)
            .representation(using: .png, properties: [:]) else { fatalError("Cannot encode PNG") }
        try png.write(to: output.appendingPathComponent("\(name)-page-\(index).png"))
    }
}
