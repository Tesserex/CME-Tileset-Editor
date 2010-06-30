using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MegaMan;
using System.Drawing;

namespace Mega_Man_Tileset_Editor
{
    public class TilesetEditor
    {
        private Tileset tileset;
        private bool dirty;

        public event Action TileAdded;

        public static TilesetEditor FromFile(string path)
        {
            return new TilesetEditor(new Tileset(path));
        }

        public static TilesetEditor CreateNew(string imagePath, int tileSize)
        {
            Image sheet = Image.FromFile(imagePath);

            Tileset tileset = new Tileset(sheet, tileSize);
            tileset.SheetPathAbs = imagePath;
            TilesetEditor editor = new TilesetEditor(tileset);
            editor.dirty = true;
            return editor;
        }

        private TilesetEditor(Tileset tileset)
        {
            this.tileset = tileset;
        }

        public string FilePath { get { return tileset.FilePath; } }
        public int SheetWidth { get { return tileset.Sheet.Width; } }
        public int SheetHeight { get { return tileset.Sheet.Height; } }
        public int Count { get { return tileset.Count; } }
        public int TileSize { get { return tileset.TileSize; } }
        public Image Sheet { get { return tileset.Sheet; } }
        public IEnumerable<string> PropertyNames { get { foreach(var p in tileset.Properties) yield return p.Name; } }

        public string TileProperties(int tileIndex)
        {
            if (tileIndex < 0 || tileIndex >= tileset.Count) return "";
            return tileset[tileIndex].Properties.Name;
        }

        public TileProperties GetProperties(string name)
        {
            return tileset.GetProperties(name);
        }

        public void AddProperties(TileProperties properties)
        {
            tileset.AddProperties(properties);
            dirty = true;
        }

        public void Play()
        {
            tileset.ForEach(t => t.Sprite.Play());
        }

        public void Stop()
        {
            tileset.ForEach(t => t.Sprite.Stop());
        }

        public void Update()
        {
            tileset.ForEach(t => t.Sprite.Update());
        }

        public void Save()
        {
            tileset.Save();
            dirty = false;
        }

        public void SaveAs(string path)
        {
            tileset.Save(path);
            dirty = false;
        }

        public void AddTile()
        {
            tileset.AddTile();
            if (TileAdded != null) TileAdded();
        }

        public void DrawTile(int tileIndex, Graphics g, int x, int y)
        {
            tileset[tileIndex].Draw(g, x, y);
        }

        public string TileName(int tileIndex)
        {
            if (tileIndex < 0 || tileIndex >= tileset.Count) return "";
            return tileset[tileIndex].Name;
        }

        public void SetTileName(int tileIndex, string name)
        {
            if (tileIndex < 0 || tileIndex >= tileset.Count) return;
            tileset[tileIndex].Name = name;
            dirty = true;
        }

        public int FrameCount(int tileIndex)
        {
            if (tileIndex < 0 || tileIndex >= tileset.Count) return 0;
            return tileset[tileIndex].Sprite.Count;
        }

        public void AddFrame(int tileIndex)
        {
            if (tileIndex < 0 || tileIndex >= tileset.Count) return;
            tileset[tileIndex].Sprite.AddFrame();
            dirty = true;
        }

        public int FrameDuration(int tileIndex, int frame)
        {
            if (frame < 0 || frame >= FrameCount(tileIndex)) return 0;
            return tileset[tileIndex].Sprite[frame].Duration;
        }

        public void SetFrameDuration(int tileIndex, int frame, int duration)
        {
            if (frame < 0 || frame >= FrameCount(tileIndex)) return;
            tileset[tileIndex].Sprite[frame].Duration = duration;
            dirty = true;
        }

        public void SetProperties(int tileIndex, string name)
        {
            if (tileIndex < 0 || tileIndex >= tileset.Count) return;
            tileset[tileIndex].Properties = tileset.GetProperties(name);
            dirty = true;
        }

        public void SetFramePosition(int tileIndex, int frame, Point location)
        {
            if (frame < 0 || frame >= FrameCount(tileIndex)) return;
            tileset[tileIndex].Sprite[frame].SetSheetPosition(new Rectangle(location, new Size(tileset.TileSize, tileset.TileSize)));
        }

        public Image TileFrame(int tileIndex, int frame)
        {
            if (frame < 0 || frame >= FrameCount(tileIndex)) return null;
            return tileset[tileIndex].Sprite[frame].CutTile;
        }
    }
}
