import Svg, { Path } from "react-native-svg";

function GalleryIconSvg(props) {
    return (
        <Svg
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 24 24"
            fill='none'
            width={20} height={20}
            {...props}>
            <Path
                style={{
                    WebkitTextIndent: "0",
                    textIndent: "0",
                    WebkitTextAlign: "start",
                    textAlign: "start",
                    lineHeight: "normal",
                    WebkitTextTransform: "none",
                    textTransform: "none",
                    blockProgression: "tb",
                    InkscapeFontSpecification: "Bitstream Vera Sans",
                }}
                d="M8 4c-.522 0-1.06.185-1.438.563C6.186 4.94 6 5.478 6 6v1h2V6h12v7h-1v2h1c.522 0 1.06-.185 1.438-.563.377-.377.562-.915.562-1.437V6c0-.522-.185-1.06-.563-1.438C21.06 4.186 20.523 4 20 4H8zM4 8c-.522 0-1.06.185-1.438.563C2.186 8.94 2 9.477 2 10v8c0 .522.185 1.06.563 1.438.377.377.915.562 1.437.562h12c.522 0 1.06-.185 1.438-.563.377-.377.562-.915.562-1.437v-8c0-.522-.185-1.06-.563-1.438C17.06 8.185 16.523 8 16 8H4zm0 2h12v8H4v-8z"
                fontFamily="Bitstream Vera Sans"
                overflow="visible"
            ></Path>
        </Svg>
    );
}

export default GalleryIconSvg;
